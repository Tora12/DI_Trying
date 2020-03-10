import numpy as np
import operator as op
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
import sympy as sy
from matplotlib import cm
from matplotlib.ticker import LinearLocator, FormatStrFormatter


# GLOBAL
rounding_variable = 3
X_min = -512
X_max = 512
Y_min = -512
Y_max = 512
# title = 'sphere_function'
title = 'test_function'
title_pdf = title + '.pdf'
# my_code = "R = X**2 + Y**2"
my_code = "R = (-1*(Y+47)*np.sin(np.sqrt(np.abs((X/2)+(Y+47))))) - (X * np.sin(np.sqrt(np.abs(X-(Y+47)))))"
#my_code = "R = (5*X**4) + (4*X**2 * Y) - (X*Y**3) + (4 * Y ** 4) - X"
fitness_min = -1000
fitness_max = 1000
# END_GLOBAL


def benchmark(X):
    return np.round((5 * X[0] ** 4) + (4 * X[0] ** 2 * X[1]) - (X[0] * X[1] ** 3) + (4 * X[1] ** 4) - X[0], 3)


def boundary(dimension):  # should have +1 here
    return [[np.round(2.0 * np.random.rand() - 1, rounding_variable) for x in range(dimension)]
                                                                        for y in range(dimension + 1)]


def min_max_sort(collection, min_first, max_first):
    if min_first == True & max_first == True:
        print("ERROR_ MIN/MAX BOTH SELECTED")
        return 0
    elif min_first:
        collection = sorted(collection, key=op.itemgetter(2), reverse=False)
    elif max_first:
        collection = sorted(collection, key=op.itemgetter(2), reverse=True)
    print('sorted ', collection)


class Individual:
    def __init__(self, dim):
        self.dimension = dim
        self.vertexes = boundary(dim)
        self.ave_fitness, self.min_fitness, self.min_fitness_location, self.name = None, None, None, 'NO_NAME'

    def calc_fitness_scores(self):
        fitness_collection = []
        for x in range(self.dimension+1): # should have +1
            fitness_collection.append(self.vertexes[x][self.dimension])
        self.ave_fitness = np.round(sum(fitness_collection)/len(fitness_collection), rounding_variable)
        self.min_fitness = np.round(min(fitness_collection), rounding_variable)
        self.min_fitness_location = np.round(fitness_collection.index(min(fitness_collection)), rounding_variable)

    def print_individual(self):
        print("This is the report for the given individual: ", self.name)
        print("Average Fitness: ", self.ave_fitness,
              " Min Fitness: ", self.min_fitness,
              " Min_fitness_location: ", self.min_fitness_location)
        for x in range(self.dimension + 1):  # should have +1
            print(self.vertexes[x])


def create_population(pop_size, dimension):
    population = []
    for x in range(pop_size):
        population.append(Individual(dimension))
        population[x].name = x
        for y in range(dimension + 1):  # should have +1
            population[x].vertexes[y].append(benchmark(population[x].vertexes[y]))
    return population


# ################################# Testing Zone #################################

populationz = create_population(100, 2)
populationz[0].calc_fitness_scores()
populationz[0].print_individual()

populationz[99].calc_fitness_scores()
populationz[99].print_individual()

# ################################# OutPut_Graph #################################

fig = plt.figure()
ax = fig.gca(projection='3d')

# Make data.
X = np.arange(X_min, X_max, 0.15)
Y = np.arange(Y_min, Y_max, 0.15)
X, Y = np.meshgrid(X, Y)
R = 0
exec(my_code)
Z = R

# Plot the surface.
surf = ax.plot_surface(X, Y, Z, cmap=cm.nipy_spectral, linewidth=1, antialiased=False)

# Customize the z axis.
ax.set_zlim(fitness_min, fitness_max)
ax.zaxis.set_major_locator(LinearLocator(10))
ax.zaxis.set_major_formatter(FormatStrFormatter('%.02f'))
# Draw a single pt ax.scatter(0,0,-990)

# Add a color bar which maps values to colors.
fig.colorbar(surf, shrink=0.5, aspect=5)
#plt.scatter(0,0,0,s=1000)

plt.title(title, fontdict=None, loc='center')
title_pdf = title + '.pdf'
fig.savefig(title_pdf, bbox_inches='tight')
plt.show()
